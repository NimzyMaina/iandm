<template>

</template>

<script>
    export default {
        name: "index",
        middleware({redirect}) {
            return redirect('/characters');
        }
    }
</script>

<style scoped>

</style>
