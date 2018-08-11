<template>
  <div id="app">
    <b-container fluid class="bv-example-row m-1">
      <!--<h3>{{title}}</h3>-->
      <b-row align-h="center">
        <spell-card v-for="r in spells" :spell=r :key="spells.index"   class="m-2"></spell-card>
      </b-row>
    </b-container>
  </div>
</template>

<script>
  import SpellCard from './SpellCard.vue'

  export default {
    components: {
      SpellCard
    },
    data() {
      return {
        title: "DnD Search Master",
        spells: []
      }
    },
    //ready: function () {
    //  this.fetchSpells();
    //},
    //methods: {
    //  fetchSpells: function () {
    //    let spells = [];

    //  }
    //},
    mounted() {
      fetch('http://localhost:56583/api/values/getspells')
        .then(response => response.json())
        .then(data => {
          this.spells = data;
        })
    }
  }

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
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }

  h1, h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>
