<template>
  <div>
    <b-modal
      title="Generate Favorite"
      id="favoritesModal"
      size="lg"
      class="modal-full"
      ok-variant="success"
      ok-title="Generate"
      method="post"
    >
      <div class="row mb-3">
        <div class="col-md-6 my-2">
          <div class="input-group input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">Filter</span>
            </div>
            <input
              type="text"
              v-model="searchString"
              class="form-control"
              aria-describedby="inputGroup-sizing"
            />
          </div>
          <div class="search-container">
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
        </div>
        <div class="col-md-6 my-2">
          <div class="info-container">
            <h3>{{selectedSpell.name}}</h3>
            <h5 v-if="selectedSpell.level">Level {{selectedSpell.level}} - {{selectedSpell.school}}</h5>
            <pre class="text-primary">{{selectedSpell.class}}</pre>

            <div class v-html="selectedSpell.desc"></div>
          </div>
        </div>
        <!-- <div class="col-md-6">
          <label class="d-block" for="levelsInput">
            <strong>Level</strong>
          </label>
          <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
            <b-input
              id="levelsInput"
              name="levelsInput"
              placeholder="ex. 9"
              type="number"
              min="0"
              max="9"
            />
          </b-input-group>
          <br />
        </div>-->
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
      selectedSpell: {}
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
    }
  }
};
</script>
<style>
.modal-body {
  padding: 1rem;
  margin-top: 0.5rem;
}
.selected {
  color: var(--white);
  background-color: var(--primary);
}
.info-container {
  padding: 1rem;
  height: 33.5rem;
  border: 0.125rem solid var(--dark);
  overflow: scroll;
}
.search-container {
  -webkit-user-select: none; /* Chrome all / Safari all */
  -moz-user-select: none; /* Firefox all */
  -ms-user-select: none; /* IE 10+ */
  user-select: none;
  height: 31rem;
  border: 0.125rem solid var(--dark);
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
</style>