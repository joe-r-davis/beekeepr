<template>
    <div class="welcome">
      <h1>{{ msg }}</h1>
      <div class="row welcome-area align-items-center">
        <div class="col-sm-12">
          <div class="welcome-boxes">
              <button class="btn buttons-welcome px-4" @click="launchSignIn">Sign in</button>
              <button class="btn buttons-welcome px-4" @click="launchRegister">Register</button>
            </div>
          </div>
        </div>
        <signIn v-on:showRegisterForm="showRegister = true" v-on:closeSignInModal="showSignIn = false" v-if="showSignIn"></signIn>
        <register v-on:showSignInForm="showSignIn = true" v-on:closeRegisterModal="showRegister = false" v-if="showRegister"></register>
    </div>
  </template>
  
  <script>
    import ErrorMsg from './ErrorMsg'
    import Register from './Register'
    import SignIn from './SignIn'
  
    export default {
      name: 'Welcome',
      components: {
        errorMsg: ErrorMsg,
        signIn: SignIn,
        register: Register
      },
      data() {
        return {
          msg: "Welcome to Beekeepr",
          showSignIn: false,
          showRegister: false
        }
      },
      methods: {
        launchSignIn() {
          this.showSignIn = true
        },
        launchRegister() {
          this.showRegister = true
        }
      },
      computed: {
        authError() {
          return this.$store.state.authError
        }
      }
    }
  </script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped>
    div {
      outline-style: solid;
      outline-color: rgb(235, 135, 213);
      outline-width: 1px;
    }
  
    .welcome {
      /* background-position: center;
        background-image: url('../assets/images/beat-locker-splash-bg.jpg');
        background-repeat: no-repeat;
        background-size: cover; */
      height: 100vh;
      width: 100%;
    }
  
    .welcome-message {
      max-width: 600px;
    }
  
    .welcome-area {
      align-items: center;
      justify-content: center;
    }
  
  
    .centerFlex {
      align-items: center;
      display: flex;
      justify-content: center;
    }
  
    .welcome-boxes {
      padding: 1rem;
      margin: 1rem;
      align-items: center;
      display: flex;
      justify-content: center;
  
    }
  
    .buttons-welcome {
      background-color: rgba(0, 102, 78, 1.0);
      border-color: rgba(0, 88, 66, 1.0);
      transition: all;
      transition-duration: 400ms;
      color: rgba(251, 251, 251, 1.0);
      margin: .5rem;
    }
  
    .buttons-welcome:hover,
    .buttons-welcome:visited,
    .buttons-welcome.focus,
    .buttons-welcome:active,
    .buttons-welcome.active:hover {
      background-color: rgba(0, 88, 66, 1.0);
      border-color: rgba(0, 77, 57, 1.0);
    }
  
    @media (min-width: 576px) {
      .welcome-message {
        width: 75%;
  
      }
    }
  </style>