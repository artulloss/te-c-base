<template>
  <div class="main">
    <h2>Product Reviews for {{ name }}</h2>
    <p class="description">{{ description }}</p>

    <div class="well-display">
      <div class="well">
        <span class="amount">{{ averageRating }}</span>
        Average Rating
      </div>

      <div class="well">
        <span class="amount">{{ numberOfOneStarReviews }}</span>
        1 Star Review {{numberOfOneStarReviews===1?'': 's'}}
      </div>

      <div class="well">
        <span class="amount">{{ numberOTwoStarReviews }}</span>
        2 Star Review{{numberOTwoStarReviews===1?'': 's'}}
      </div>

      <div class="well">
        <span class="amount">{{numberOfThreeStarReviews}}</span>
        3 Star Review{{numberOfThreeStarReviews===1?'': 's'}}
      </div>

      <div class="well">
        <span class="amount">{{numberOfFourStarReviews}}</span>
        4 Star Review{{numberOfFourStarReviews===1?'': 's'}}
      </div>

      <div class="well">
        <span class="amount">{{numberOfFiveStarReviews}}</span>
        5 Star Review{{numberOfFiveStarReviews===1?'': 's'}}
      </div>
    </div>

    <div class="review" v-for="r in reviews" v-bind:key="r.id" v-bind:class=" {favorited: r.favorited}">
      <h4>{{ r.reviewer }}</h4>
      <div class="rating">
        <img
          src="../assets/star.png"
          v-for="n in r.rating"
          v-bind:key="n"
          class="ratingStar"
          v-bind:title="r.rating + ' Star Review'"
        />
      </div>
      <h3>{{ r.title }}</h3>
      <p>{{ r.review }}</p>
      <p>Favorite? <input type="checkbox" v-model="r.favorited"/></p>
    </div>
  </div>
</template>

<script>
export default {
  name: "product-review",
  data() {
    return {
      name: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all your squirelly friends.",
      reviews: [
        {
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review: "It certainly is a book. Bla bla bla bla.",
          rating: 3,
          id: 1,
          favorited: true
        },
        {
          reviewer: "Katie Dwyer",
          title: "case of the mondays",
          review: "vue is actually really fun and cool",
          rating: 1,
          id: 2,
          favorited: false
        },
        {
          reviewer: "Mickey Mouse",
          title: "golly",
          review: "happpy thanksgiving thursday",
          rating: 5,
          id: 3,
          favorited: true
        },
      ],
    };
  },
  computed: {
    averageRating() {
      //get the sum of all of the ratings
      let sum = this.reviews.reduce((currentSum, review) => {
        return currentSum + review.rating;
      }, 0);

      //divide the sum by the number of reviews
      return sum / this.reviews.length;
    },
    numberOfOneStarReviews() {
      return this.reviews.reduce((currentCount, review) => {
        /* if (review.rating===1){
                  return currentCount + 1;
              } else {
                  return currentCount; 
              }*/
        return currentCount + (review.rating === 1);
      }, 0);
    },
    numberOTwoStarReviews() {
      return this.reviews.reduce((currentCount, review) => {
        return currentCount + (review.rating === 2);
      }, 0);
    },
    numberOfThreeStarReviews() {
      return this.reviews.reduce((currentCount, review) => {
        return currentCount + (review.rating === 3);
      }, 0);
    },
    numberOfFourStarReviews() {
      return this.reviews.reduce((currentCount, review) => {
        return currentCount + (review.rating === 4);
      }, 0);
    },
    numberOfFiveStarReviews() {
      return this.reviews.reduce((currentCount, review) => {
        return currentCount + (review.rating === 5);
      }, 0);
    },
  },
};
</script>

<style scoped>
div.main {
  margin: 1rem 0;
}
div.main div.well-display {
  display: flex;
  justify-content: space-around;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

div.main div.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}

div.main div.review div.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

div.main div.review div.rating img {
  height: 100%;
}

div.main div.review p {
  margin: 20px;
}

div.main div.review h3 {
  display: inline-block;
}

div.main div.review h4 {
  font-size: 1rem;
}

div.main div.review.favorited {
    background-color: lightyellow;
}
</style>