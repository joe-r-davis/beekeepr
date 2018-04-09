
import Vue from 'vue'
import Router from 'vue-router'
import Welcome from '@/components/Welcome'
import Home from '@/components/Home'
import MyBeeswax from '@/components/MyBeeswax'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Welcome',
      component: Welcome
    },
    {
      path: '/home',
      name: 'Home',
      component: Home
    },
    {
    path: '/mybeeswax',
    name: 'MyBeeswax',
    component: MyBeeswax
  }
  ]
})