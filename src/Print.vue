<template>
  <div>
    <div v-for="spell in spells" :key="spell.index">
      <div class="printable text-justify">
        <div id="infoContainer" class="info-container py-4">
          <div id="infoSubcontainer" class="info-subcontainer px-3 pb-5 pt-1 align-self-top">
            <span class="info-header">
              <h3>{{spell.name}}</h3>
              <h5 v-if="spell.level">Level {{spell.level}} - {{spell.school}}</h5>
              <small class="text-primary">{{spell.class}}</small>
            </span>
            <span class="extended-description text-justify">
              <strong v-if="spell.index" class="d-block pt-2 text-primary">Description</strong>
              <span v-html="formattedDescription(spell)"></span>
              <strong v-if="spell.index" class="text-primary">Classes</strong>
              <p>{{spell.class}}</p>
              <p v-html="formattedComponents(spell)"></p>
              <strong v-if="spell.index" class="text-primary">School</strong>
              <p>{{spell.school}}</p>
            </span>
          </div>
        </div>
        <hr />
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
.print-mode {
  margin: 1.5rem;
  margin-top: -2.5rem;
}
</style>