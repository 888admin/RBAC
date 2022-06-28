import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/MenuUpd',
    name: 'MenuUpd',
    component: () => import('../views/MenuUpd.vue')
  },
  {
    path: '/MenuCreate',
    name: 'MenuCreate',
    component: () => import('../views/MenuCreate.vue')
  },
  {
    path: '/Menulist',
    name: 'Menulist',
    component: () => import('../views/Menulist.vue')
  },
  {
    path: '/Menu',
    name: 'Menulist',
    component: () => import('../views/Menu.vue')
  },
  {
    path: '/',
    name: 'Login',
    component: () => import('../views/Login.vue')
  },
  {
    path: '/HomeView',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
