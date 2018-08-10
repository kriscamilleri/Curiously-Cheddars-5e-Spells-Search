import Vue from 'vue'
import App from './App.vue'

import ElementUI  from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css';

Vue.use(ElementUI)

new Vue({
  name: 'app',
  components: {

  },
  el: '#app',
  render: h => h(App)
})

