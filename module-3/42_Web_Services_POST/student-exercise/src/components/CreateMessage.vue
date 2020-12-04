<template>
  <form v-on:submit.prevent>
    <div class="field">
      <label for="title">Title</label>
      <input type="text" name="title" v-model="message.title" />
    </div>
    <div class="field">
      <label for="messageText">Message</label>
      <input type="text" name="messageText" v-model="message.messageText" />
    </div>
    <div class="actions">
      <button type="submit" v-on:click="saveMessage()">Save Message</button>
    </div>
  </form>
</template>

<script>
import messageService from "../services/MessageService";

export default {
  name: "create-message",
  props: ["topicId"],
  data() {
    return {
      message: {
        id: Math.floor(Math.random() * (1000 - 100) + 100), // bruh
        topicId: this.topicId,
        title: "",
        messageText: "",
      },
    };
  },
  methods: {
    saveMessage() {
      messageService
        .createMessage(this.message)
        .then((res) => {
          if (res.status === 201) {
            this.$router.push(`/${this.message.topicId}`);
          }
        })
        .catch((err) => {
          alert(`Error occured: ${err.message}`);
        });
    },
  },
};
</script>

<style></style>
