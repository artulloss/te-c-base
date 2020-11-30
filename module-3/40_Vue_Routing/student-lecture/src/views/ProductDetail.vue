<template>
  <div>
    <h1>{{ product.name }}</h1>
    <p class="description">{{ product.description }}</p>
    <div class="actions">
      <router-link v-bind:to="{ name: 'products' }"
        >Back to products</router-link
      >&nbsp;
      <router-link
        v-bind:to="{ name: 'add-review', params: { id: product.id } }"
        >Back to products</router-link
      >&nbsp;
    </div>
    <div class="well-display">
      <average-summary />
      <star-summary rating="1" />
      <star-summary rating="2" />
      <star-summary rating="3" />
      <star-summary rating="4" />
      <star-summary rating="5" />
    </div>
  </div>
</template>

<script>
import AverageSummary from "@/components/AverageSummary";
import StarSummary from "@/components/StarSummary";
import AddReview from "@/components/AddReview.vue";
import ReviewList from "@/components/ReviewList.vue";

export default {
  created() {
    const activeProductID = this.$route.params.id;
    this.$store.commit("SET_ACTIVE_PRODUCT", activeProductID);
  },
  computed: {
    product() {
      return this.$store.state.products.find(
        (p) => p.id === this.$store.state.activeProduct
      );
    },
  },
  components: [AverageSummary, StarSummary, AddReview, ReviewList],
};
</script>
