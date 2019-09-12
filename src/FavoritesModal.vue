<template>
  <div>
    <b-modal
      title="Create Spellbook"
      id="favoritesModal"
      size="lg"
      class="modal-full"
      ok-variant="success"
      ok-title="Generate"
      method="post"
    >
      <div class="row mb-3">
        <div class="col-md-6 my-2">
          <div class="row">
            <div class="col-md-12">
              <p>Select as many spells as you'd like from below, and hit generate to create your character's spellbook.</p>
            </div>
          </div>
          <div class="input-group input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">Search</span>
            </div>
            <input type="text" v-model="searchString" class="form-control" />
          </div>
          <div class="search-container border">
            <div class="card-sm">
              <ul class="list-group list-group-flush">
                <li
                  class="list-group-item"
                  :class="selectedSpell.index === spell.index ? 'selected' : ''"
                  v-for="spell in filteredSpells"
                  v-on:click="selectSpell(spell.index)"
                  :spell="spell"
                  :key="spell.index"
                >{{spell.name}}</li>
                <li class="list-group-item" v-if="filteredSpells.length === 0">No spells found.</li>
              </ul>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <div class="border p-2">
                <span
                  class="btn btn-primary"
                  v-on:click="addSpell(selectedSpell)"
                  :class="selectedSpell.index === undefined ? 'disabled' : ''"
                >Add Spell</span>
                <span class="btn btn-info text-white float-right">Filters...</span>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <span
                v-for="spell in addedSpells"
                :key="spell.index"
                class="badge badge-light p-2 m-2 h1 border-primary border"
              >
                <small>Lvl{{spell.level}}</small>
                {{spell.name}}
                <small class="close-button">
                  <span class="p-1 badge badge-sm badge-secondary m-1">X</span>
                </small>
              </span>
            </div>
          </div>
        </div>
        <div class="col-md-6 my-2">
          <div id="infoContainer" class="info-container border py-4">
            <div id="infoSubcontainer" class="info-subcontainer px-3 pb-5 pt-1">
              <span class="info-header">
                <h3>{{selectedSpell.name}}</h3>
                <h5
                  v-if="selectedSpell.level"
                >Level {{selectedSpell.level}} - {{selectedSpell.school}}</h5>
                <small class="text-primary">{{selectedSpell.class}}</small>
              </span>
              <div class="text-justify" v-html="extendedDescription"></div>
            </div>
          </div>
          <div v-if="paginationEnabled === true" class="info-footer mx-3">
            <span
              class="btn btn-dark float-right"
              :class="nextEnabled ? '' : 'disabled'"
              @
              v-on:click="nextPage()"
            >Next</span>
            <span
              class="btn btn-dark"
              :class="previousEnabled ? '' : 'disabled'"
              v-on:click="previousPage()"
            >Previous</span>
          </div>
        </div>
      </div>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "FavoritesModal",
  props: {
    spells: Array
  },
  data() {
    return {
      searchString: "banishment",
      selectedSpell: {},
      addedSpells: [],
      containerWidth: Number,
      pageCount: 0,
      paginationEnabled: false,
      nextEnabled: true,
      previousEnabled: true
    };
  },
  computed: {
    filteredSpells: function() {
      const searchString = this.searchString.toLowerCase();
      let spells = this.spells.filter(
        c => c.name.toLowerCase().indexOf(searchString) != -1
      );
      return spells;
    },
    extendedDescription: function() {
      return this.selectedSpell.desc + "<p class='extended-description'></p>";
    }
  },
  mounted() {
    const container = document.getElementsByClassName("info-container")[0];
    this.containerWidth = container.offsetWidth;
    window.addEventListener("resize", this.handleResize);
  },
  methods: {
    selectSpell: function(index) {
      this.selectedSpell = this.spells.find(c => c.index === index);
      this.resetPage();
    },
    addSpell: function(spell) {
      //disable button when nothing to add
      if (this.selectedSpell.index === undefined) {
        return;
      }
      const existingSpell = this.addedSpells.find(x => x.index === spell.index);
      if (existingSpell === undefined) {
        this.addedSpells.push(spell);
      }
    },
    previousPage: function() {
      if (!this.previousEnabled) {
        return;
      }
      this.pageCount -= 1;
      const subcontainer = document.getElementById("infoSubcontainer");
      const container = document.getElementById("infoContainer");
      this.containerWidth = container.offsetWidth;
      const translate = this.pageCount * (this.containerWidth + 15);

      subcontainer.style.transform = `translateX(-${translate}px)`;
      this.togglePaginationButtons();
      console.log("previous");
    },
    nextPage: function() {
      if (!this.nextEnabled) {
        return;
      }
      this.pageCount += 1;
      const subcontainer = document.getElementById("infoSubcontainer");
      const container = document.getElementById("infoContainer");
      this.containerWidth = container.offsetWidth;
      const translate = this.pageCount * (this.containerWidth + 15);

      subcontainer.style.transform = `translateX(-${translate}px)`;
      this.togglePaginationButtons();
      console.log("next");
    },
    togglePaginationButtons: function() {
      //TODO CONTINUE HERE
      let self = this;
      const executable = function(self) {
        const subcontainer = document.getElementById("infoSubcontainer");
        const container = document.getElementById("infoContainer");
        // this.window.width = subcontainer.offsetWidth;
        self.containerWidth = container.offsetWidth;
        const lastPosition = self.getElementOffset(
          subcontainer.lastChild.lastChild
        ).left;
        console.log(subcontainer.lastChild.lastChild);
        const firstPosition = self.getElementOffset(subcontainer).left;
        const scrollDistance = self.pageCount * (self.containerWidth + 15);
        console.log(
          "self.pageCount:" +
            self.pageCount +
            ", self.containerWidth:" +
            self.containerWidth
        );
        console.log(
          "scrolldistance:" + scrollDistance + ", lastPosition:" + lastPosition
        );
        const nextPage = scrollDistance < lastPosition;
        console.log("subcontainer.lastChild");
        console.log(subcontainer.lastChild);

        self.nextEnabled = nextPage;
        const previousPage = scrollDistance > firstPosition;
        self.previousEnabled = previousPage;
      };
      this.delayExecution(10, executable);
    },
    resetPage: function() {
      const subcontainer = document.getElementById("infoSubcontainer");
      this.paginate();
      this.togglePaginationButtons();
      this.pageCount = 0;
    },
    paginate: function() {
      let self = this;
      //TODO: should turn into its own component, however, for now - a timeout should give vue enough time to add the elements to the DOM and allow for position calculations
      setTimeout(function() {
        const container = document.getElementById("infoContainer");
        const subcontainer = document.getElementById("infoSubcontainer");
        const firstPosition = self.getElementOffset(
          subcontainer.lastElementChild
        ).left;
        const lastPosition = self.getElementOffset(
          subcontainer.lastChild.lastChild
        ).left;
        subcontainer.style.transform = `translateX(0px)`;
        self.pageCount = 0;
        if (firstPosition !== lastPosition) {
          self.paginationEnabled = true;
          console.log("test");
        } else {
          self.paginationEnabled = false;
        }
      }, 10);
    },
    getElementOffset: function(el) {
      const rect = el.getBoundingClientRect();
      return {
        top: rect.top + window.pageYOffset,
        left: rect.left + window.pageXOffset
      };

      // If you want to support IE8 and lower
      // Use
      //
      // top: rect.top + (window.pageYOffset || document.documentElement.scrollTop),
      // left: rect.left + (window.pageXOffset || document.documentElement.scrollLeft),
    },
    handleResize: function() {
      const subcontainer = document.getElementById("infoSubcontainer");
      const container = document.getElementById("infoContainer");
      // this.window.width = subcontainer.offsetWidth;
      this.containerWidth = container.offsetWidth;
      const translate = this.pageCount * (this.containerWidth + 15);
      this.resetPage();
      // subcontainer.style.transform = `translateX(-${translate}px)`;
      subcontainer.style.transform = ``;
    },
    delayExecution(milliseconds, executable) {
      const self = this;
      setTimeout(function() {
        executable(self);
      }, milliseconds);
    }
  }
};
</script>
<style>
.extended-description:after {
  content: "&nbsp";
  visibility: hidden;
}
.close-button {
  font-size: 60%;
}
.modal .badge {
  font-size: 130%;
}
:root {
  --modal-container-footer: 14rem;
  --info-footer: 3em;
  --info-column-gap: 15px;
}
input.form-control {
  padding: 0.75rem 1.25rem;
}
.selected {
  color: var(--white);
  background-color: var(--primary);
}
.info-container {
  margin: 1rem;
  max-height: calc(80vh - (var(--info-footer) + var(--modal-container-footer)));
  -webkit-column-width: 20rem;
  -moz-column-width: 20rem;
  column-width: 20rem;
  break-inside: avoid-page;
  -moz-column-fill: auto;
  column-fill: auto;
  -webkit-column-gap: var(--info-column-gap);
  -moz-column-gap: var(--info-column-gap);
  column-gap: var(--info-column-gap);
  -webkit-column-rule: 1px dotted var(--dark);
  -moz-column-rule: 1px dotted var(--dark);
  column-rule: 1px dotted var(--dark);
  overflow: hidden;
  text-overflow: ellipsis;
}
.info-container .info-header {
  -webkit-column-span: all;
  -moz-column-span: all;
  column-span: all;
}
.info-subcontainer {
  text-overflow: ellipsis;
  max-height: calc(80vh - (var(--info-footer) + var(--modal-container-footer)));
}
.info-container {
  -ms-overflow-style: none;
  scrollbar-width: none;
}
.info-subcontainer::-webkit-scrollbar {
  height: 0;
  display: none;
}
.info-footer {
  height: var(--info-footer);
  margin-top: -calc(
    80vh - (var(--info-footer) + var(--modal-container-footer))
  );
}
.search-container {
  -webkit-user-select: none; /* Chrome all / Safari all */
  -moz-user-select: none; /* Firefox all */
  -ms-user-select: none; /* IE 10+ */
  user-select: none;
  height: 15rem;
  overflow: scroll;
}
.search-container li.list-group-item {
  border-radius: 0.25rem;
  cursor: pointer;
}

.search-container li:active,
.search-container li:hover {
  background-color: var(--dark);
}
.input-group > .custom-file,
.input-group > .custom-select,
.input-group > .form-control {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}

.modal .input-group .input {
  width: 100%;
  max-width: 100%;
}

.modal .input-group {
  width: 100%;
  max-width: 100%;
}

.max-width-override {
  max-width: 100%;
}

.modal {
  padding-right: 0 !important;
}

.modal-full {
  min-width: 100%;
  margin: 0 !important;
}

.modal-full .modal-dialog {
  min-width: 100%;
  margin: 0;
}
@media only screen and (min-width: 600px) {
  .modal-full .modal-content {
    min-height: 100vh;
    padding: 4rem;
  }

  .modal .close {
    margin-top: -4rem;
    margin-right: -4rem;
    font-size: 2rem;
  }
}
.modal .custom-select {
  background: none;
}

.modal-body {
  padding: 1rem;
  margin-top: 0.5rem;
}
</style>