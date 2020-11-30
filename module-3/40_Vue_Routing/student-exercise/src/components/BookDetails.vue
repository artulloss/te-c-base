<template>
  <div class="card" v-bind:class="{ read: book.read }">
    <h2 class="book-title">{{ book.title }}</h2>
    <h3 class="book-author">{{ book.author }}</h3>
    <img
      v-if="book.isbn"
      v-bind:src="
        'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
      "
    />
    <p class="book-read">
      {{ book.read ? "I have read this book" : "I have not read this book" }}
    </p>
  </div>
</template>

<script>
export default {
  name: "book-details",
  props: {
    book: Object,
  },
};
</script>

<style scoped>
.card {
  margin: 0 auto;
}
</style>
