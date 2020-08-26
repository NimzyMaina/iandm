<template>
  <nav aria-label="Page navigation example">
    <ul class="pagination justify-content-end">
      <li class="page-item" :class="{disabled : !pag.first.active}">
        <a class="page-link" @click.prevent="load(pag.first.url)" href="#" tabindex="-1" aria-disabled="true">First</a>
      </li>
      <li class="page-item" :class="{disabled : !pag.prev.active}">
        <a class="page-link" @click.prevent="load(pag.prev.url)" href="#" tabindex="-1" aria-disabled="true">Previous</a>
      </li>
      <li class="page-item" :class="{disabled : !pag.next.active}">
        <a class="page-link" @click.prevent="load(pag.next.url)" href="#" tabindex="-1" aria-disabled="true">Next</a>
      </li>
      <li class="page-item" :class="{disabled : !pag.last.active}">
        <a class="page-link" @click.prevent="load(pag.last.url)" href="#" tabindex="-1" aria-disabled="true">Last</a>
      </li>
    </ul>
  </nav>
</template>

<script>
    export default {
        name: "Paginator",
        mounted() {

        },
        computed: {
            pag() {
                return this.$store.getters.links;
            }
        },
        methods: {
            async load(link) {
                try {
                    await this.$store.dispatch('fetchCharacters',link);
                }catch (e) {
                    console.log('error',e);
                }
            },
            goTo(link){
                console.log('goto', link);
            }
        }
    }
</script>

<style scoped>

</style>
