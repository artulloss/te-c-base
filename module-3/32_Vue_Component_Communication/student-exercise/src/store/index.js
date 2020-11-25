import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const findIndexOfObjectInArray = (array, object) => {
  return array.findIndex((obj) => {
    return arePropsIdentical(obj, object);
  });
};

const arePropsIdentical = (objectOne, objectTwo) => {
  for (const prop in objectOne) {
    if (objectOne[prop] !== objectTwo[prop]) {
      return false;
    }
  }
  return true;
};

export default new Vuex.Store({
  state: {
    books: [
      {
        title: "Kafka on the Shore",
        author: "Haruki Murakami",
        read: false,
        isbn: "9781400079278",
      },
      {
        title: "The Girl With All the Gifts",
        author: "M.R. Carey",
        read: true,
        isbn: "9780356500157",
      },
      {
        title: "The Old Man and the Sea",
        author: "Ernest Hemingway",
        read: true,
        isbn: "9780684830490",
      },
      {
        title: "Le Petit Prince",
        author: "Antoine de Saint-Exupéry",
        read: false,
        isbn: "9783125971400",
      },
    ],
  },
  mutations: {
    toggleBookRead(state, bookToToggle) {
      const index = findIndexOfObjectInArray(state.books, bookToToggle);
      state.books[index].read = !bookToToggle.read;
    },
    addBook(state, book) {
      // Check if the books contains a book with the same isbn number
      if (
        !state.books.reduce((a, b) => a || arePropsIdentical(b, book), false)
      ) {
        state.books.push(book);
      } else {
        alert("This book already exists");
      }
    },
  },
  actions: {},
  modules: {},
  strict: true,
});
