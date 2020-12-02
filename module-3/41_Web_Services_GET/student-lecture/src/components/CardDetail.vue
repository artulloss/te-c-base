<template>
  <div>
    <div class="loading" v-if="isLoading">
      <img src="../assets/ping_pong_loader.gif" />
    </div>
    <div v-else>
      <h1>{{ card.title }}</h1>
      <p>{{ card.description }}</p>
      <comments-list v-bind:comments="card.comments" />
    </div>
  </div>
</template>

<script>
import boardsService from "../services/BoardService";
import CommentsList from "./CommentsList.vue";

export default {
  name: "card-detail",
  props: ["comments"],
  data() {
    return {
      card: {
        title: "",
        description: "",
        status: "",
        comments: [],
      },
    };
  },
  created() {
    const boardId = this.$route.params.boardID;
    const cardId = this.$route.params.cardID;
    boardsService.getCard(boardId, cardId).then((response) => {
      console.log(response);
      this.card = response;
      this.isLoading = false;
    });
  },
  components: { CommentsList },
};
</script>
