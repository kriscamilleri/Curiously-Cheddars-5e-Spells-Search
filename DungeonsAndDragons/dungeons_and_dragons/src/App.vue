<template>
  <div id="app">
    <spell-nav-bar @sideBarOn="captureSideBarStatus" @searchText="captureSearchText" :sideBarOn="sideBarOn"></spell-nav-bar>
    <div id="wrapper" :class="{ toggled: sideBarOn }">
      <div id="sidebar-wrapper" class="bg-light">
          <spell-filters></spell-filters>
      </div>
      <div  id="page-content-wrapper">
        <b-container fluid class="bv-example-row m-1">
          <b-row align-h="center">
            <spell-card v-for="r in filteredSpells" :spell=r :key="r.index" class="m-2"></spell-card>
          </b-row>
        </b-container>
    </div>
  </div> 
  </div>
</template>

<script>
import SpellNavBar from "./SpellNavBar.vue";
import SpellCard from "./SpellCard.vue";
import SpellFilters from "./SpellFilters.vue";

export default {
  components: {
    SpellCard,
    SpellNavBar,
    SpellFilters
  },
  data() {
    return {
      title: "DnD Search Master",
      sideBarOn: false,
      searchText: "",
      spells: [],
      clases: [
        "Bard",
        "Cleric",
        "Druid",
        "Paladin",
        "Ranger",
        "Sorcerer",
        "Warlock",
        "Wizard"
      ]
    };
  },
  computed: {
    filteredSpells: function() {
      var self = this;
      if (!this.searchText) {
        return this.spells;
      }
      return this.spells.filter(function(spell) {
        let lowerText = self.searchText.toLowerCase();
        return (
          spell.name
            .toLowerCase()
            .trim()
            .indexOf(lowerText) > -1
        );
      });
    }
  },
  methods: {
    captureSideBarStatus(sideBarOn) {
      this.sideBarOn = sideBarOn;
    },
    captureSearchText(searchText) {
      this.searchText = searchText;
    }
  },
  mounted() {
    fetch("http://localhost:56583/api/values/getspells")
      .then(response => response.json())
      .then(data => {
        this.spells = data;
      });
  }
};
</script>

<style>
.card {
  min-width: 250px;
  max-width: 350px;
  max-width: 0.1rem;
}
/*.card-columns {
    display: inline-block;
    column-break-inside: avoid;
  }*/
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

h1,
h2 {
  font-weight: normal;
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
}

.nav-button {
  border-radius: 0.25rem;
}

.nav-button a {
  color: #fff !important;
  display: inline-block;
  font-weight: 400;
  text-align: center;
  white-space: nowrap;
  vertical-align: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  border: 1px solid transparent;
  padding-top: 0.375rem;
  padding-right: 0.75rem !important;
  padding-bottom: 0.375rem;
  padding-left: 0.75rem !important;
  font-size: 1rem;
  line-height: 1.5;
  border-radius: 0.25rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  margin-bottom: 0 !important;
  margin-top: 0 !important;
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
  z-index: 1000;
  position: fixed;
  right: 380px;
  width: 0;
  height: 100%;
  margin-right: -380px;
  overflow-y: auto;
  -webkit-transition: all 0.5s ease;
  -moz-transition: all 0.5s ease;
  -o-transition: all 0.5s ease;
  transition: all 0.5s ease;
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
}
</style>
