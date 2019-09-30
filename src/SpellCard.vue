
<template>
  <div>
    <b-card
      img-top
      v-b-toggle="'descSpell' + spell.index"
      tag="article"
      class="mx-auto m-1 spell-card shadow text-left"
      :border-variant="classColor"
      header-bg-variant="primary"
      header-text-variant="white"
    >
      <h4 class="card-title text-primary" data-toggle="collapse" aria-controls="collapseOne">
        {{spell.name}}
        <span class="badge-shrinker align-middle">
          <b-badge variant="warning" v-if="spell.concentration == true">Conc</b-badge>
          <b-badge variant="success" v-if="spell.ritual == true">Rit</b-badge>
        </span>
      </h4>
      <h6 class="card-subtitle mb-2 text-muted" v-html="formattedSubtitle"></h6>
      <p class="card-text text-sm text-muted" align-h="start">
        <b-collapse :id="'descSpell'+spell.index" class="details-text text-justify">
          <br />
          <strong>Description</strong>
          <span v-html="spell.desc"></span>
          <strong>Classes</strong>
          <p>{{spell.class}}</p>
          <strong>Components</strong>
          <p>{{spell.material != null ? spell.material : 'None.'}}</p>
        </b-collapse>
      </p>
    </b-card>
  </div>
</template>

<script>
export default {
  name: "SpellCard",
  props: {
    spell: {
      index: Number,
      name: String,
      desc: String,
      higherLevel: String,
      range: String,
      ritual: Boolean,
      duration: String,
      concentration: Boolean,
      castingTime: String,
      level: Number,
      school: String,
      class: Array,
      levelDesc: String,
      classDesc: String,
      rangeDesc: String,
      componentDesc: String,
      verbal: Boolean,
      material: Boolean,
      somatic: Boolean,
      source: String,
      page: Number
    }
  },
  methods: {
    expandCard: function() {}
  },
  watch: {},
  computed: {
    formattedSubtitle: function() {
      return (
        this.formattedLevel +
        ", " +
        this.formattedRange +
        ",<br> " +
        this.formattedDuration +
        ", " +
        this.formattedCastingTime +
        "."
      );
    },
    formattedLevel: function() {
      let result = "";
      if (this.spell.level == 0) {
        result = "Cantrip";
      } else {
        result = "Level " + this.spell.level;
      }
      return "<strong class='text-danger'>" + result + "</strong>";
    },
    formattedRange: function() {
      return (
        "<strong class='text-info'>Range&nbsp;</strong>" +
        this.spell.range.replace("feet", "Feet")
      );
    },
    formattedDetails: function() {
      let description = this.formattedDescription;
      let classes = this.formattedClasses;
      let components = this.formattedComponents;
      return description + classes + components;
    },
    formattedClasses: function() {
      // let classArr = this.spell.class;
      let classArray = this.spell.class.split(",");

      let classes =
        "<strong>Classes</strong><p>" + classArray.join(", ") + ".</p>";

      return classes;
    },
    formattedDescription: function() {
      let description = "<strong>Description </strong>" + this.spell.desc;
      return description;
    },
    formattedDuration: function() {
      let result = "<strong class='text-warning'>Duration&nbsp;</strong>";
      if (this.spell.concentration && this.spell.duration.length > 0) {
        let cleanedDuration = this.spell.duration;
        cleanedDuration = cleanedDuration.replace("Concentration, ", "");
        result += cleanedDuration[0].toUpperCase() + cleanedDuration.slice(1);
      } else {
        result += this.spell.duration;
      }
      return result; // capitalize first letter
    },
    formattedCastingTime: function() {
      return (
        "<strong class='text-success'>Cast&nbsp;</strong>" +
        this.spell.casting_time
      );
    },
    formattedComponents: function() {
      let array = [];
      if (this.spell.somatic) {
        array.push("Somatic");
      }
      if (this.spell.verbal) {
        array.push("Verbal");
      }
      if (this.spell.material) {
        array.push("Material");
      }
      if (array.length > 0) {
        return "<strong>Components</strong><p>" + array.join(", ") + ".</p>";
      }
      return "";
    },
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
