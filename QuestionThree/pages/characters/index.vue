<template>
  <div>
    <nav-menu></nav-menu>

    <div class="container">
      <div class="row mt-5">
        <h3>Game of Thrones Characters</h3>
        <div class="table-responsive">

          <p><strong>Note:</strong> Click row to view more.</p>

          <paginator></paginator>
          <table class="table table-bordered table-striped">
            <thead>
              <tr>
                <th>Name</th>
                <th>Aliases</th>
                <th>Gender</th>
                <th>Born</th>
                <th>Died</th>
                <th>Series</th>
                <th>Played By</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="x in character_list" @click="navigate(x.url)">
                <td>{{show_one(x.name)}}</td>
                <td>{{show_many(x.aliases)}}</td>
                <td>{{show_one(x.gender)}}</td>
                <td>{{show_one(x.born)}}</td>
                <td>{{show_one(x.died)}}</td>
                <td>{{show_many(x.tvSeries)}}</td>
                <td>{{show_many(x.playedBy)}}</td>
              </tr>
            </tbody>
          </table>
          <paginator></paginator>

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
import Paginator from '~/components/Paginator.vue'
import NavMenu from '~/components/NavMenu.vue'

export default {
    components: { Paginator, NavMenu },
    data() {
        return {
            fullPage: true
        }
    },
    async mounted(){
        await this.$store.dispatch('fetchCharacters');
    },
    computed: {
        isLoading(){
            return this.$store.getters.is_loading;
        },
        character_list() {
            return this.$store.getters.characters;
        }
    },
    methods: {
        navigate(url){
            let id = url.replace('https://anapioficeandfire.com/api/characters/','');
            this.$router.push('/characters/view/'+id);
        }
    }
}
</script>

<style>

</style>
