<template>

    <div class="my-beeswax">
        <navbar></navbar>
        <div class="container-fluid">
            <div class="row">
                <div class="container">    
                    <div class="row">
                        <div class="col-sm-12 dashboard-intro">
                            Hello {{user.username}}, here you may post your own keeps, manage your vaults, and be awesome.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</template>

<script>
    import navbar from './Navbar'
    export default {
        name: "MyBeeswax",
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
    div {
        outline-color: turquoise;
        outline-style: solid;
        outline-width: 1px;
    }

    .dashboard-intro {
        background-color: rgba(0, 102, 78, 1.0);
        color: white;
        margin-top: 2rem;
        padding: 1rem;
    }
</style>