<template>
    <div class="background">
        <div class="register">

            <errorMsg v-if="authError.error">{{authError.message}}</errorMsg>

            <form class="p-4" action="#" @submit.prevent="submit">
                <div class="form-group">
                    <label class="ml-4" for="username" required>Name: </label>
                    <input type="text" id="username" class="form-control" v-model="user.name" placeholder="My Name" required>
                </div>
                <div class="form-group">
                    <label class="ml-4" for="email">Email: </label>
                    <input type="text" id="email" class="form-control" v-model="user.email" placeholder="my@address.com" required>
                </div>
                <div class="form-group">
                    <label class="ml-4" for="password">Password: </label>
                    <input type="password" id="password" class="form-control" v-model="user.password" placeholder="********" required>
                </div>
                <button type="submit" class="btn btn-primary registerButton px-4">Register</button>
                <button class="btn btn-secondary px-4" @click="closeModal">Close</button>
            </form>
            <div class="text-center pt-4">
                <a href="#" class="text-muted" @click.prevent="showSignInForm">Already registered? Sign in here.</a>
            </div>
        </div>
    </div>
</template>

<script>
    import ErrorMsg from './ErrorMsg'
    export default {
        name: "Register",
        components: {
            errorMsg: ErrorMsg
        },
        data() {
            return {
                user: {
                    name: "",
                    email: "",
                    password: ""
                }
            };
        },
        computed: {
            authError() {
                return this.$store.state.authError
            }
        },
        methods: {
            submit() {
                console.log("I hate my life.");
                this.$store.dispatch("registerUser", this.user);
            },
            showSignInForm() {
                this.$emit("showSignInForm");
                this.$emit("closeRegisterModal");
            },
            closeModal() {
                this.$emit("closeRegisterModal");
            }
        }
    };
</script>

<style scoped>
    .background {
        background-color: rgba(0, 0, 0, 0.8);
        position: fixed;
        width: 100%;
        height: 100vh;
        top: 0;
        left: 0;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .register {
        width: 95%;
        background-color: rgba(0, 102, 78, 1.0);
        padding-top: 2rem;
        padding-bottom: 2rem;
        border-radius: 4px;
    }

    @media (min-width: 576px) {
        div.register {
            width: 50%;
        }
    }

    .registerForm {
        padding: 1rem;
    }

    form {
      background-color: rgba(82, 79, 38, 1.0);
        color: rgba(251, 251, 251, 1.0);
    }

    .registerButton {
      background-color: rgba(0, 102, 78, 1.0);
        border-color: rgba(0, 88, 66, 1.0);
        transition: all;
        transition-duration: 400ms;
        color: rgba(251, 251, 251, 1.0);
        margin: .5rem;
    }

    .registerButton:hover {
        background-color:  rgba(0, 88, 66, 1.0);
        border-color:  rgba(0, 88, 66, 1.0);
    }

    .registerButton:active,
    .registerButton:visited,
    .registerButton:focus {
      background-color: rgba(0, 88, 66, 1.0);
      border-color: rgba(0, 77, 57, 1.0);
    }

    .button {
        display: flex;
        justify-content: flex-end;
        align-self: center;
    }
</style>