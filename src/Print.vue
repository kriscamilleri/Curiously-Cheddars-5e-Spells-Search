<template>
  <div>
    <div v-for="spell in spells" :key="spell.index">
      <div class="printable">
        <h3>{{spell.name}}</h3>
        <p>{{formattedDetails(spell)}}</p>
      </div>
    </div>
  </div>
</template>
<script>
import SpellParser from "./mixins/SpellParser.vue";

export default {
  name: "Print",
  mixins: [SpellParser],
  props: {
    spells: Array
  },
  methods: {}
};
</script>
<style>
</style>