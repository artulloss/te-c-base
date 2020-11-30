import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home";
import MyBooks from "../views/MyBooks";
import NewBook from "../views/NewBook";
import BookDetails from "../views/BookDetails";
Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: Home,
  },
  {
    path: "/myBooks",
    name: "myBooks",
    component: MyBooks,
  },
  {
    path: "/addBook",
    name: "newBook",
    component: NewBook,
  },
  {
    path: "/book/:isbn",
    name: "book",
    component: BookDetails,
  },
];

const router = new VueRouter({
  mode: "history",
  routes,
});

export default router;
