<template>
    <div class="welcome">
        <navbar></navbar>
        <div class="container-fluid">
            <div class="row align-items-center">
                <div class="col-sm-12 d-flex justify-content-center">
                    <div class="beekeepr-welcome-logo">
                        <img src="../assets/beekeepr-main-logo.png" alt="beekeepr" class="logo-img" width="200px">
                    </div>
                </div>
                <div class="col-sm-12 d-flex justify-content-center">
                    <div class="welcome-to-beekeepr">
                        <h3>Welcome to Beekeepr!</h3>
                        <p>
                            Feel free to look around! If you want to save or share your favorite photos or links ("keeps"), or build up collections of favorites ("vaults"), you'll need to login or register first. Have fun!
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import navbar from './Navbar'
    export default {
        name: "Welcome",
        data() {
            return {};
        },
        components: {
            navbar,
        },
        computed: {
            user() {
                return this.$store.state.user;
            }
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

    .beekeepr-welcome-logo {
        padding: 2rem;
        width: 20rem;
    }

    .welcome-to-beekeepr {
        width: 20rem;
        padding: 1.5rem;
        background-color: rgba(201, 218, 208, 1.0)
    }
</style>