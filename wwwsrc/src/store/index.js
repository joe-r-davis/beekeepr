import vue from "vue";
import vuex from "vuex";
import axios from "axios";
import router from "../router";

var production = !window.location.host.includes("localhost");
var baseUrl = production ? "//something.herokuapp.com/" : "//localhost:5000/";

var api = axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

var auth = axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
});

vue.use(vuex);

export default new vuex.Store({
  state: {
    user: {},
    authError: {
      error: false,
      message: ""
    },
    allPublicKeeps: [],
    myVaults: [],
    userStatus: false
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    setUserStatus(state, payload) {
      state.userStatus = payload;
    },
    setAuthError(state, error) {
      state.authError = {
        error: error.error,
        message: error.message
      };
    },
    setKeeps(state, allPublicKeeps) {
      state.allPublicKeeps = allPublicKeeps;
    },
    setMyKeeps(state, allMyKeeps) {
      state.allMyKeeps = allMyKeeps;
    },
    setMyVaults(state, myVaults) {
      state.myVaults = myVaults;
    }
  },
  actions: {
    registerUser({ commit, dispatch }, user) {
      auth
        .post("register", user)
        .then(res => {
          var newUser = res.data;
          commit("setUser", newUser);
          router.push({
            name: "Home"
          });
        })
        .catch(err => {
          console.log(err);
          commit("setAuthError", {
            error: true,
            message:
              "Register failed: Invalid username, email, or password given"
          });
        });
    },

    editUser({ commit, dispatch }, user) {
      api
        .put("users/" + user._id, user)
        .then(res => {
          var updatedUser = res.data;
          commit("setUser", updatedUser);
        })
        .catch(err => {
          console.log(err);
        });
    },

    loginUser({ commit, dispatch }, user) {
      auth
        .post("login", user)
        .then(res => {
          var newUser = res.data;
          console.log("logged-in user:", newUser);
          commit("setUser", newUser);

          // Ask Randy about this one
          // commit("setAuthError", { error: false, message: "" });

          //Maybe here we commit "setActiveKeeps" and "setActiveVaults"
          // dispatch("createProject", newUser._id);

          router.push({
            name: "Home"
          });
        })
        .catch(err => {
          console.log(err);
          commit("setAuthError", {
            error: true,
            message: "Log-in failed: Invalid username or password"
          });
        });
    },

    authenticateUser({ commit, dispatch }) {
      auth
        .get("authenticate")
        .then(res => {
          var sessionUser = res.data;
          console.log("returning user:", sessionUser);
          commit("setUser", sessionUser);

          //Maybe here we commit "setActiveKeeps" and "setActiveVaults"
          // dispatch("createProject", newUser._id);
        })
        .catch(err => {
          console.error(err);
        });
    },
    logoutUser({ commit, dispatch }) {
      auth
        .delete("logout")
        .then(() => {
          console.log("User logged out");
          commit("setUser", {});

          // Ask Randy about this one
          // commit("setAuthError", { error: false, message: "" });

          // maybe here we commit ("setActiveKeeps") and ("setActiveVaults") to empty

          router.push({
            name: "Welcome"
          });
        })
        .catch(err => {
          console.log(err);
          commit("setAuthError", {
            error: true,
            message: "User must log in or register to post Keeps or add Vaults"
          });
        });
    },
    getAllPublicKeeps({ commit, dispatch }) {
      api
        .get("/keeps")
        .then(res => {
          console.log("Keeps", res.data);
          var allPublicKeeps = res.data;
          allPublicKeeps.sort((keepA, keepB) => {
            return keepB.createdAt - keepA.createdAt;
          });
          commit("setKeeps", allPublicKeeps);
        })
        .catch(err => {
          console.log(err);
        });
    },
    getAllMyKeeps({ commit, dispatch }) {
      api
        .get("/keeps/userkeeps")
        .then(res => {
          console.log("MyKeeps", res.data);
          var allMyKeeps = res.data;
          allMyKeeps.sort((keepA, keepB) => {
            return keepB.createdAt - keepA.createdAt;
          });
          commit("setMyKeeps", allMyKeeps);
        })
        .catch(err => {
          console.log(err);
        });
    },
    getMyVaults({ commit, dispatch }) {
      api
        .get("/vaults/uservaults")
        .then(res => {
          console.log("MyVaults", res.data);
          var myVaults = res.data;
          myVaults.sort((vaultA, vaultB) => {
            return vaultB.createdAt - vaultA.createdAt;
          });
          commit("setMyVaults", myVaults);
        })
        .catch(err => {
          console.log(err);
        });
    },

    updateShareCount({ commit, dispatch }, keep) {
      // console.log('Shared Project Shared',payload)
      keep.shareCount = keep.shareCount + 1;
      // console.log('Shared Project Shared2',payload)
      api
        .put(`keeps/${keep.id}`, keep)
        .then(() => {
          dispatch("getAllPublicKeeps");
        })
        .catch(err => {
          console.log(err);
        });
    },
    updateViewCount({ commit, dispatch }, keep) {
      // console.log('Shared Project Shared',payload)
      keep.viewCount = keep.viewCount + 1;
      // console.log('Shared Project Shared2',payload)
      api
        .put(`keeps/${keep.id}`, keep)
        .then(() => {
          dispatch("getAllPublicKeeps");
        })
        .catch(err => {
          console.log(err);
        });
    },
    createKeep({ commit, dispatch }, keep) {
      api.post("/Keeps", keep).then(res => {
        dispatch("getAllPublicKeeps").catch(err => {
          console.log(err);
        });
      });
    },
    deleteKeep({ commit, dispatch }, keep) {
      api.delete(`keeps/${keep.id}`, keep).then(res => {
        dispatch("getAllMyKeeps").catch(err => {
          console.log(err);
        });
      });
    },
    createVault({ commit, dispatch }, vault) {
      api.post("/vaults", vault).then(res => {
        dispatch("getMyVaults").catch(err => {
          console.log(err);
        });
      });
    },
    deleteVault({ commit, dispatch }, vault) {
      api.delete(`vaults/${vault.id}`, vault).then(res => {
        dispatch("getMyVaults").catch(err => {
          console.log(err);
        });
      });
    }
  }
});
