<template>

  <div>
    <nav-menu></nav-menu>

    <div class="container">
      <div class="row mt-5">
        <h3>Game of Thrones - {{show_one(character.name)}}</h3>

        <div class="row mt-5">
          <client-only>
            <vue-json-to-table :data="character"></vue-json-to-table>
          </client-only>
        </div>

      </div>
    </div>

    <client-only>
      <loading :active.sync="isLoading"
               :can-cancel="false"
               :is-full-page="fullPage"></loading>
    </client-only>
  </div>

</template>

<script>
    import NavMenu from '~/components/NavMenu.vue'
    import J2Table from "~/components/J2Table.vue";
    export default {
        name: "detail",
        components: {
            NavMenu, "vue-json-to-table": J2Table
        },
        data() {
            return {
                character : {},
                fullPage: true
            }
        },
        async mounted() {
            let id = this.$route.params.id;

            try{
                this.character = await this.getCharacter(id, false);
            }
            catch (e) {
                console.log('error',e);
            }

        },
        computed: {
            isLoading(){
                return this.$store.getters.is_loading;
            },
        }
    }
</script>

<style scoped>

</style>
