import Vue from "vue";
import App from "./App.vue";
// import {BootstrapVue} from "bootstrap-vue";
import Badge from "bootstrap-vue";
import Button from "bootstrap-vue";
import Card from "bootstrap-vue";
import Collapse from "bootstrap-vue";
import Form from "bootstrap-vue";
import FormCheckbox from "bootstrap-vue";
import InputGroup from "bootstrap-vue";
import Nav from "bootstrap-vue";
import Navbar from "bootstrap-vue";
import Link from "bootstrap-vue";
import Layout from "bootstrap-vue";
import "./bootstrap-theme/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.min.css";

Vue.use(
  Badge,
  Button,
  Card,
  Collapse,
  Form,
  FormCheckbox,
  InputGroup,
  Nav,
  Navbar,
  Link,
  Layout
);
//import ElementUI  from 'element-ui'
//import 'element-ui/lib/theme-chalk/index.css';

//Vue.use(ElementUI)

new Vue({
  name: "app",
  components: {},
  el: "#app",
  render: h => h(App)
});
