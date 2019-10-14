<template>
  <div id="app">
    <title>{{spellBookTitle}}</title>

    <meta name="viewport" content="width=device-width, user-scalable=false;" />
    <spell-nav-bar
      @sideBarOn="captureSideBarStatus"
      @searchText="captureSearchText"
      @spells="spells"
      :navTitle="spellBookTitle"
      :sideBarOn="sideBarOn"
    ></spell-nav-bar>
    <div id="wrapper" :class="{ toggled: sideBarOn }">
      <div id="sidebar-wrapper" class="bg-light">
        <spell-filters
          :classFilters="classFilters"
          @classFilters="captureClassFilters"
          :levelFilters="levelFilters"
          @levelFilters="captureLevelFilters"
          :sourceFilters="sourceFilters"
          @sourceFilters="captureSourceFilters"
          :schoolFilters="schoolFilters"
          @schoolFilters="captureSchoolFilters"
        ></spell-filters>
      </div>
      <!-- <add-spell></add-spell> -->
      <favorites-modal :spells="spells"></favorites-modal>
      <div id="page-content-wrapper">
        <b-container fluid class="bv-example-row m-1">
          <b-row :class="{ 'd-none': dataLoading }" id="spellContainer" align-h="center">
            <spell-card v-for="r in filteredSpells" :spell="r" :key="r.index" class="m-2"></spell-card>
          </b-row>
          <div v-if="dataLoading" class="text-center p-5">
            <h2>Loading data...</h2>
          </div>
          <b-pagination
            align="center"
            class="p-4 mt-4"
            v-model="currentPage"
            :total-rows="spellSize"
            :per-page="pageSize"
            aria-controls="spellContainer"
          ></b-pagination>
        </b-container>
      </div>
    </div>
  </div>
</template>

<script>
/* IDEAS
Minimal mode
Fix text to be more obvious
Size adjustment
Filter by ritual or concentration
Expand all cards
PWA
Filter fixed width when closing
*/

import SpellNavBar from "./SpellNavBar.vue";
import SpellCard from "./SpellCard.vue";
import AddSpell from "./AddSpell.vue";
import SpellFilters from "./SpellFilters.vue";
import FavoritesModal from "./FavoritesModal.vue";

export default {
  components: {
    SpellCard,
    // AddSpell,
    FavoritesModal,
    SpellNavBar,
    SpellFilters
  },
  data() {
    return {
      spellBookFilter: [],
      spellBookTitle: "CC's Spell Search",
      // title: "DnD Search Master",
      dataLoading: true,
      sideBarOn: false,
      searchText: "",
      spells: [],
      currentPage: 1,
      spellSize: 0,
      pageSize: 20,
      classFilters: [
        "bard",
        "cleric",
        "druid",
        "paladin",
        "ranger",
        "sorcerer",
        "warlock",
        "wizard"
      ],
      sourceFilters: ["EE", "PHB", "SCAG", "XGtE"],
      levelFilters: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
      schoolFilters: [
        "Abjuration",
        "Conjuration",
        "Divination",
        "Enchantment",
        "Evocation",
        "Illusion",
        "Necromancy",
        "Transmutation"
      ],
      classes: [
        "bard",
        "cleric",
        "druid",
        "paladin",
        "ranger",
        "sorcerer",
        "warlock",
        "wizard"
      ],
      levels: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
      sources: ["EE", "PHB", "SCAG", "XGtE"],
      schools: [
        "Abjuration",
        "Conjuration",
        "Divination",
        "Enchantment",
        "Evocation",
        "Illusion",
        "Necromancy",
        "Transmutation"
      ]
    };
  },
  computed: {
    filteredSpells: function() {
      var searchText = this.searchText;
      let spells = this.spells;
      spells = this.filterSpellBook(spells);
      spells = this.filterSearch(spells, searchText);
      spells = this.filterClasses(spells);
      spells = this.filterLevels(spells);
      spells = this.filterSources(spells);
      spells = this.filterSchools(spells);
      this.spellSize = spells.length;

      const firstSpellIndex = (this.currentPage - 1) * this.pageSize;
      const lastSpellIndex = this.currentPage * this.pageSize;

      spells = spells.slice(firstSpellIndex, lastSpellIndex);
      return spells;
    }
  },
  methods: {
    captureSideBarStatus(sideBarOn) {
      this.sideBarOn = sideBarOn;
    },
    captureSearchText(searchText) {
      this.searchText = searchText;
    },
    captureClassFilters(value) {
      this.classFilters = value;
    },
    captureLevelFilters(value) {
      this.levelFilters = value;
    },
    captureSourceFilters(value) {
      this.sourceFilters = value;
    },
    captureSchoolFilters(value) {
      this.schoolFilters = value;
    },
    filterSearch(spells, searchText) {
      if (searchText.length > 0) {
        spells = spells.filter(function(spell) {
          let lowerText = searchText.toLowerCase();
          return (
            spell.name
              .toLowerCase()
              .trim()
              .indexOf(lowerText) > -1
          );
        });
      }
      return spells;
    },
    filterSpellBook(spells) {
      if (this.spellBookFilter.length == 0) {
        return spells;
      }
      console.log(this.spellBookFilter);
      const filteredSpells = spells.filter(
        c => this.spellBookFilter.indexOf(c.index) !== -1
      );
      return filteredSpells;
    },
    filterClasses(spells) {
      let classFilters = this.classFilters.map(function(value) {
        return value[0].toUpperCase() + value.slice(1);
      });

      if (this.classFilters.length != this.classes.length) {
        spells = spells.filter(function(spell) {
          let x = spell.class.split(",");
          let intersection = x.filter(n => classFilters.includes(n));
          if (intersection.length > 0) {
            return spell;
          }
        });
      }
      return spells;
    },
    filterLevels(spells) {
      let levelFilters = this.levelFilters;
      if (levelFilters.length != this.levels.length) {
        spells = spells.filter(function(spell) {
          let x = spell.level;
          let intersection = levelFilters.includes(parseInt(x));
          if (intersection) {
            return spell;
          }
        });
      }
      return spells;
    },
    filterSources(spells) {
      let sourceFilters = this.sourceFilters;
      if (sourceFilters.length != this.sources.length) {
        spells = spells.filter(function(spell) {
          let source = spell.page.split(" ")[0].toUpperCase();
          console.log(source + ", " + sourceFilters);
          let intersection = sourceFilters.includes(source);
          if (intersection) {
            return spell;
          }
        });
      }
      return spells;
    },
    filterSchools(spells) {
      let schoolFilters = this.schoolFilters;
      if (schoolFilters.length != this.schools.length) {
        spells = spells.filter(function(spell) {
          let x = spell.school;
          let intersection = schoolFilters.includes(x);
          if (intersection) {
            return spell;
          }
        });
      }
      return spells;
    },
    parseSpells(url) {
      fetch(url)
        .then(response => {
          if (!response.ok) {
            throw new Error("HTTP error " + response.status);
          }
          return response.json();
        })
        .then(data => {
          let parsedData = [];
          for (let i = 0; i < data.length; i++) {
            data[i].index = this.spells.length + 1;
            this.spells.push(data[i]);
          }
          this.spells = this.spells.sort((a, b) => a.name > b.name);
          this.dataLoading = false;
        });
      // let x = this.$jsonp(url);
      // this.$jsonp(url, { name: "MyName", age: 20 })
      //   .then(json => {
      //     // Success.
      //     console.log(json);
      //   })
      //   .catch(err => {
      //     // Failed.
      //   });
      // .then(function() {
      //   console.log("woop!");
      //   if (!response.ok) {
      //     throw new Error("HTTP error " + response.status);
      //   }
      //   return response.json();
      // })
      // .then(data => {
      //   let parsedData = [];
      //   console.log("woop!");

      //   for (let i = 0; i < data.length; i++) {
      //     data[i].index = this.spells.length + 1;
      //     this.spells.push(data[i]);
      //   }
      //   this.spells = this.spells.sort((a, b) => a.name > b.name);
      //   this.dataLoading = false;
      // });
    },
    parseUrl() {
      let uri = window.location.search.substring(1);
      let params = new URLSearchParams(uri);
      let spellsString = params.get("spellbook");
      let spellBookTitle = params.get("spellbookname");
      if (spellsString) {
        this.spellBookFilter = spellsString.split("-").map(c => parseInt(c));
      }
      if (spellBookTitle) {
        this.spellBookTitle = spellBookTitle;
      }

      console.log(this.spellBookTitle);
    }
  },
  mounted() {
    let self = this;
    const firstUrl = "/pastebin-1";
    const secondUrl = "/pastebin-2";
    this.parseUrl();

    this.parseSpells(firstUrl);
    this.parseSpells(secondUrl);
  }
};
</script>

<style>
/*.card-columns {
    display: inline-block;
    column-break-inside: avoid;
  }*/

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}

h1,
h2 {
  /* font-weight: normal; */
}

a {
  color: #007bff;
}

#app {
  margin-right: 15px;
  margin-right: 15px;
}

/* SIDEBAR */
body {
  overflow-x: hidden;
  font-size: 1rem;
}

#wrapper {
  padding-right: 0;
  -webkit-transition: all 0.5s ease;
  -moz-transition: all 0.5s ease;
  -o-transition: all 0.5s ease;
  transition: all 0.5s ease;
}

#wrapper.toggled {
  padding-right: 380px;
}

#sidebar-wrapper {
  z-index: 1029;
  position: fixed;
  right: 380px;
  width: 0;
  height: 100%;
  margin-right: -380px;
  overflow-y: auto;
  -webkit-transition: all 0.5s ease-in-out;
  -moz-transition: all 0.5s ease-in-out;
  -o-transition: all 0.5s ease-in-out;
  transition: all 0.5s ease-in-out;
  margin-top: -10px;
}

#wrapper.toggled #sidebar-wrapper {
  width: 380px;
}

#page-content-wrapper {
  width: 100%;
  position: absolute;
  padding: 0px;
}

#wrapper.toggled #page-content-wrapper {
  position: absolute;
  margin-left: -380px;
}

/* Sidebar Styles */

.sidebar-nav {
  position: absolute;
  top: 0;
  width: 380px;
  margin: 0;
  padding: 0;
  list-style: none;
}

.sidebar-nav > .sidebar-brand {
  height: 65px;
  font-size: 18px;
  line-height: 60px;
}

.sidebar-nav > .sidebar-brand a {
  color: #999999;
}

.sidebar-nav > .sidebar-brand a:hover {
  color: #fff;
  background: none;
}

@media (min-width: 768px) {
  #wrapper {
    padding-right: 0;
  }

  #sidebar-wrapper {
    width: 0;
  }
  #wrapper.toggled #sidebar-wrapper {
    width: 380px;
  }
  #page-content-wrapper {
    position: relative;
  }
  #wrapper.toggled #page-content-wrapper {
    position: relative;
    margin-left: 0;
  }

  h1,
  h2,
  h3,
  h4,
  h5,
  h6,
  .h1,
  .h2,
  .h3,
  .h4,
  .h5,
  .h6 {
    font-weight: 400;
  }
}
</style>
