import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'
import VueAxios from 'vue-axios'
import uiComponents from './components/UI'

var app = createApp(App);

uiComponents.forEach(component => app.component(component.name, component));

app.use(VueAxios, axios).use(store).use(router).mount('#app')