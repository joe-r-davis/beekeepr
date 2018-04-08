<template>
  <div class="home">
    <navbar></navbar>
    <div class="container-fluid">
      
    </div>
  </div>
</template>

<script>
  import navbar from './Navbar'
  export default {
    name: "Home",
    data() {
      return {};
    },
    components: {
      navbar,
    },
    computed: {
      // isHomeRoute() {
      //   return this.$route.path === "/Home" || this.$route.path === "/home";
      // },
      // user() {
      //   return this.$store.state.user;
      // }
    },
    methods: {
      // userProfile() {
      //   this.$router.push({ path: "/UserProfile" });
      // }
    }
  };
</script>

<style scoped>
  div {
    outline-color: turquoise;
    outline-style: solid;
    outline-width: 1px;
  }
</style>