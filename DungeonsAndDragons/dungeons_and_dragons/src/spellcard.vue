
<template>
  <div cols="4">
    <b-card
            
            img-top
            tag="article"
            class="mx-auto m-1 spell-card shadow text-left"
            :border-variant="classColor"
            header-bg-variant="primary"
            header-text-variant="white">
            <h4 class="card-title">
              <a class="text-primary" data-toggle="collapse" v-b-toggle="'descSpell' + spell.index"  aria-expanded="true" aria-controls="collapseOne">
                {{spell.name}}
              </a>
              <span class="badge-shrinker align-middle" >
                <b-badge variant="success" v-if="spell.ritual != 'no'">Rit.</b-badge>
                <b-badge variant="warning" v-if="spell.concentration != 'no'">Conc.</b-badge>
              </span>
            </h4>
            <h6 class="card-subtitle mb-2 text-muted" v-html="formattedSubtitle"></h6>
      <p class="card-text text-sm text-muted" align-h="start">
        <b-collapse :id="'descSpell'+spell.index" class="details-text  text-justify">
          <br />
          <span v-html="formattedDetails"></span>
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
      index: 0,
      name: "",
      desc: "",
      higherLevel: "",
      range: "",
      ritual: false,
      duration: "",
      concentration: false,
      castingTime: "",
      level: 0,
      school: "",
      class: [],
      levelDesc: "",
      classDesc: "",
      rangeDesc: "",
      componentDesc: "",
      verbal: false,
      material: false,
      somatic: false,
      source: "",
      page: 0
    }
  },
  methods: {
    expandCard: function() {}
  },
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
      return "<strong>" + result + "</strong>";
    },
    formattedRange: function() {
      return (
        "<strong>R&nbsp;</strong>" + this.spell.range.replace("feet", "Feet")
      );
    },
    formattedDetails: function() {
      let description = this.formattedDescription;
      let classes = this.formattedClasses;
      let components = this.formattedComponents;
      return description + classes + components;
    },
    formattedClasses: function() {
      let classArr = this.spell.class;

      let classes =
        "<strong>Classes</strong><p>" + classArr.join(", ") + ".</p>";

      return classes;
    },
    formattedDescription: function() {
      let description = "<strong>Description </strong>" + this.spell.desc;
      return description;
    },
    formattedDuration: function() {
      let result = "<strong>D&nbsp;</strong>";
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
      return "<strong>C&nbsp;</strong>" + this.spell.castingTime;
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

      return "<strong>Components</strong><p>" + array.join(", ") + ".</p>";
    },
    classColor: function() {
      return "secondary";
    }
  }
};
//Stacked progress bar to denote spell class requirement
</script>
<style>
.details-text {
  font-size: 0.85rem;
}
.component-text {
  font-size: 0.85rem;
}
.badge-shrinker {
  font-size: 0.85rem;
}
.card-title {
  cursor: pointer;
}
</style>
