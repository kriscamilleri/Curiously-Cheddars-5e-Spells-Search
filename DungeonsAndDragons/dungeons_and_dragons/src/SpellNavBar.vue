<template>
    <b-navbar toggleable="md" type="light" variant="white" class="shadow-sm fixed-top ">
      <b-navbar-brand href="#">Free's Spell Search</b-navbar-brand>
      <b-navbar-toggle target="nav_collapse" class="float-right"></b-navbar-toggle>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item href="#" class="float-left">Github</b-nav-item>
        </b-navbar-nav>
        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
          <b-nav-item href="#menu-toggle"  class="my-2 my-sm-0 p-0 ml-2 mr-4 nav-button btn-secondary"  :class="{ active: sideBarOn}" size="sm" v-on:click.prevent="toggleSideBar" id="menu-toggle" >Filter...</b-nav-item>
          <div class="input-group">
            <b-form-input size="md" class="" type="text" @input="toggleSearch" v-model="localSearchText"  placeholder="Search" />
              <div class="input-group-append">
                <b-nav-item href="#search"  class="nav-button btn-primary" size="sm" id="menu-toggle" >Go</b-nav-item>
            </div>
          </div>
          </b-nav-form>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
</template>

<script>
export default {
  name: "SpellNavBar",
  props: {
    sideBarOn: false
  },
  data: function() {
    return {
      localSearchText: ""
    };
  },
  methods: {
    toggleSideBar: function() {
      this.$emit("sideBarOn", !this.sideBarOn);
    },
    toggleSearch: function() {
      this.$emit("searchText", this.localSearchText);
    }
  }
};
</script>

<style>
/*Necessary to left align text when nav-collapse is open*/
@media (max-width: 767px) {
  #nav_collapse a {
    margin-top: 0.5rem;
    margin-left: 0.5rem;
    margin-bottom: 0.5rem;
    float: left;
  }
}
</style>