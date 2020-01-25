<template>
  <div>
    <div v-for="spell in spells" :key="spell.index">
      <div class="printable">
        <h3>{{spell.name}}</h3>
        <p>{{spell.formattedDetails}}</p>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Print",
  props: {
    spells: Array
  },
  methods: {}
};
</script>
<style>
</style>