import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue);
//import ElementUI  from 'element-ui'
//import 'element-ui/lib/theme-chalk/index.css';

//Vue.use(ElementUI)

new Vue({
  name: 'app',
  components: {

  },
  el: '#app',
  render: h => h(App)
})

