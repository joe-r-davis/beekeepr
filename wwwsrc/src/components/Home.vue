<template>
  <div class="home">
    <navbar></navbar>
    <div class="container-fluid">
      <div class="row">
        <div class="card-deck all-keeps-wrapper d-flex justify-content-center">
          <keeps :keep='keep' v-for='keep in keeps' :key='keep.id'></keeps>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import navbar from './Navbar'
  import Keeps from './Keeps'
  export default {
    name: "Home",
    data() {
      return {};
    },
    components: {
      navbar,
      keeps: Keeps,

    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.allPublicKeeps;
        console.log(this.$store.state.allPublicKeeps)
      },
      myKeeps() {
        return this.$store.state.allMyKeeps;
        console.log(this.$store.state.allMyKeeps)
      },
      vaults() {
        return this.$store.state.myVaults;
        console.log(this.$store.state.myVaults)
      }
    },
    mounted() {
      this.$store.dispatch("getAllPublicKeeps")
      this.$store.dispatch("getAllPublicKeeps")
      this.$store.dispatch("getMyVaults")
    },
    methods: {

    }
  };
</script>

<style scoped>
  /* div {
    outline-color: turquoise;
    outline-style: solid;
    outline-width: 1px;
  } */

  .all-keeps-wrapper {
    text-align: center;
    border-top-color: rgba(0, 102, 78, 1.0);
    border-top-style: solid;
    border-top-width: 2px;
    padding-top: 2rem;
    width: 100%;
    height: 100%;
    background-image: linear-gradient(-180deg, rgba(214, 206, 160, 1.0), rgba(123, 101, 75, 1.0));
  }
</style>