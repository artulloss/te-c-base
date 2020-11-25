<template>
  <!--
    Form	.new-book-form
    Title Input Field	.title-input
    Author Input Field	.author-input
    ISBN Input Field	.isbn-input
  -->
  <form v-on:submit.prevent="submitNewBook" class=".new-book.form">
    <input
      class="title-input"
      type="text"
      placeholder="Title"
      v-model="newBook.title"
    />
    <input
      class="author-input"
      type="text"
      placeholder="Author"
      v-model="newBook.author"
    />
    <input
      class="isbn-input"
      type="text"
      placeholder="ISBN"
      v-model="newBook.isbn"
    />
    <input type="submit" />
  </form>
</template>

<script>
export default {
  name: "new-book-form",
  data: () => {
    return {
      newBook: {
        read: false,
      },
    };
  },
  methods: {
    submitNewBook() {
      const newBook = this.newBook;
      if (newBook.title && newBook.author && newBook.isbn) {
        this.$store.commit("addBook", newBook);
        this.newBook = {
          read: false,
        };
      } else {
        alert("The book you're adding is missing data.");
      }
    },
  },
};
</script>

<style scoped>
form > * {
  margin: 8px;
}
</style>
