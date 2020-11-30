<template>
  <div>
    <book-details v-bind:book="book" />
  </div>
</template>

<script>
import BookDetails from "../components/BookDetails";

export default {
  components: { BookDetails },
  computed: {
    book() {
      let book = this.$store.state.books.find(
        (book) => book.isbn === this.$route.params.isbn
      );
      if (!book) {
        book = this.$store.state.popularBooks.find(
          (book) => book.isbn === this.$route.params.isbn
        );
      }
      if (!book) {
        book = {
          title: "This book doesn't exist in our library",
          author: "Unknown",
          read: true,
          isbn: "111111111111",
        };
      }
      return book;
    },
  },
};
</script>

<style></style>
