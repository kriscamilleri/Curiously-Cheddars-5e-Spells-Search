<template>
  <div id="app">
    <el-row>
      <h1>{{ msg }}</h1>
      <el-col :span="6">
        test
      </el-col>
      <el-col  :span="18"> 
        <el-col v-for="r in 10" :xs="12" :sm="12" :lg="8" :key="r">
          <card-container></card-container>
        </el-col>
      </el-col>
    </el-row>
  </div>
</template>

<script>
  import CardContainer from './CardContainer.vue'

  export default {
    components: {CardContainer},
    data() {
      return {
        msg: "DnD Search Master"
      }
    }
  }

</script>

<style>
  .el-card.is-always-shadow, .el-card.is-hover-shadow:focus, .el-card.is-hover-shadow:hover {
    margin: 1rem;
    box-shadow: 0 .075rem .25rem rgba(0,0,0,.075);
  }


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
