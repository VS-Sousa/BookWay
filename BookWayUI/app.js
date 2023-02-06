const routes = [
    { path: "/home", component: home },
    { path: "/genre", component: genre },
    { path: "/book", component: book }
]

const router = VueRouter.createRouter({ 
    history: VueRouter.createWebHashHistory(),
    routes 
})

const app = Vue.createApp({})

app.use(router)

app.mount("#app")