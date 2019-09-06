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
      <div class="row">
        <div class="col-md-12">
          <p>Select as many spells as you'd like from below, and hit generate to create your character's spellbook.</p>
        </div>
      </div>
      <div class="row mb-3">
        <div class="col-md-6 my-2">
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
              >{{spell.name}}</span>
            </div>
          </div>
        </div>
        <div class="col-md-6 my-2">
          <div class="info-container">
            <h3>{{selectedSpell.name}}</h3>
            <h5 v-if="selectedSpell.level">Level {{selectedSpell.level}} - {{selectedSpell.school}}</h5>
            <pre class="text-primary">{{selectedSpell.class}}</pre>
            <div class="text-justify" v-html="selectedSpell.desc"></div>
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
      searchString: "",
      selectedSpell: {},
      addedSpells: []
    };
  },
  computed: {
    filteredSpells: function() {
      const searchString = this.searchString.toLowerCase();
      let spells = this.spells.filter(
        c => c.name.toLowerCase().indexOf(searchString) != -1
      );
      return spells;
    }
  },
  methods: {
    selectSpell: function(index) {
      this.selectedSpell = this.spells.find(c => c.index === index);
    },
    addSpell: function(spell) {
      console.log("onclick");
      //disable button when nothing to add
      if (this.selectedSpell.index === undefined) {
        return;
      }

      const existingSpell = this.addedSpells.find(x => x.index === spell.index);
      if (existingSpell === undefined) {
        console.log("existingspell");
        this.addedSpells.push(spell);
      }
    }
  }
};
</script>
<style>
.modal .badge {
  font-size: 130%;
}
:root {
  --modal-container-footer: 7rem;
}
input.form-control {
  padding: 0.75rem 1.25rem;
}
.selected {
  color: var(--white);
  background-color: var(--primary);
}
.info-container {
  padding: 1rem;
  height: calc(80vh - var(--modal-container-footer));
  overflow: scroll;
  -webkit-column-count: 2;
  -moz-column-count: 2;
  column-count: 2;
  -webkit-column-width: 20rem;
  -moz-column-width: 20rem;
  column-width: 20rem;
  -moz-column-fill: auto;
  column-fill: auto;
  -webkit-column-gap: 4em;
  -moz-column-gap: 4em;
  column-gap: 4em;
  -webkit-column-rule: 1px dotted var(--dark);
  -moz-column-rule: 1px dotted var(--dark);
  column-rule: 1px dotted var(--dark);
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

.modal-full .modal-content {
  min-height: 100vh;
  padding: 4rem;
}

.modal .close {
  margin-top: -4rem;
  margin-right: -4rem;
  font-size: 2rem;
}

.modal .custom-select {
  background: none;
}

.modal-body {
  padding: 1rem;
  margin-top: 0.5rem;
}
</style>