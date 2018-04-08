<template>
  <div class="home">
    <h1>This is going to be the Home vue! </h1>
    <h3>{{user.name}}</h3>
        <h3>{{user.email}}</h3>
    <button class="btn btn-secondary my-2 my-sm-0" @click="logout">Logout</button>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {};
  },
  components: {},
  computed: {
    isHomeRoute() {
      return this.$route.path === "/Home" || this.$route.path === "/home";
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logoutUser");
      this.$router.push({ path: "/welcome" });
    },
    userProfile() {
      this.$router.push({ path: "/UserProfile" });
    }
  }
};
</script>

<style scoped>

</style>