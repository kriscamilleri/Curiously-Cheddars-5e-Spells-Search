
<template>
  <div>
    <b-card
      img-top
      v-b-toggle="'descSpell' + spell.id"
      tag="article"
      class="mx-auto m-1 spell-card shadow text-left"
      :border-variant="classColor"
      header-bg-variant="primary"
      header-text-variant="white"
    >
      <h4
        class="card-title text-primary"
        data-toggle="collapse"
        aria-controls="collapseOne"
      >{{spell.name}}</h4>
      <h6 class="card-subtitle mb-2 text-muted" v-html="formattedSubtitle(spell)"></h6>
      <span class="badge-shrinker align-middle">
        <b-badge variant="warning" v-if="spell.conc == 'true'">conc</b-badge>
        <b-badge variant="success" v-if="spell.ritual == 'true'">Ritual</b-badge>
      </span>
      <p class="card-text text-sm text-muted" align-h="start">
        <b-collapse :id="'descSpell'+spell.id" class="details-text text-justify">
          <br />
          <strong class="text-primary">Description</strong>
          <span v-html="formattedDescription(spell)"></span>
          <strong class="text-primary">Classes</strong>
          <p>{{spell.class}}</p>
          <p v-html="formattedComponents(spell)"></p>
          <strong class="text-primary">School</strong>
          <p>{{spell.school}}</p>
        </b-collapse>
      </p>
    </b-card>
  </div>
</template>

<script>
import SpellParser from "./mixins/SpellParser.vue";

export default {
  name: "SpellCard",
  mixins: [SpellParser],
  props: {
    spell: {
      id: Number,
      name: String,
      desc: Array,
      higher: String,
      range: String,
      ritual: Boolean,
      duration: String,
      conc: Boolean,
      casting: String,
      level: String,
      school: String,
      class: Array,
      source: String,
      page: String
    }
  },
  methods: {
    expandCard() {},
    convertJsonArrayToHtml(jsonArr) {
      let text = this.splitMulti(jsonArr, ["'],['", "'], ['"]);
      text[0] = text[0].replace("['", "");
      text[text.length - 1] = text[text.length - 1].replace(/']/g, "");
      let html = `<p>${text.join("</p><p>")}</p>`;
      return html;
    },
    splitMulti(str, tokens) {
      var tempChar = tokens[0]; // We can use the first token as a temporary join character
      for (var i = 1; i < tokens.length; i++) {
        str = str.split(tokens[i]).join(tempChar);
      }
      str = str.split(tempChar);
      return str;
    }
  },
  watch: {},
  computed: {
    classColor: function() {
      return "muted";
    }
  }
};
//Stacked progress bar to denote spell class requirement
</script>
<style>
.details-text {
  font-size: 0.95rem;
}

.component-text {
  font-size: 1rem;
}

.badge-shrinker {
  font-size: 1rem;
}
@media (max-width: 576px) {
  .spell-card.card {
    cursor: pointer;
    min-height: 160px;
    min-width: 80vw;
    max-width: 80vw;
  }
}

.card {
  cursor: pointer;
  min-height: 160px;
  min-width: 18rem;
  max-width: 18rem;
}
.navbar-brand {
  margin-right: 0.5rem;
}
</style>
