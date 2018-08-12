
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
      <p class="card-text text-sm " align-h="start">
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
      index: null,
      name: null,
      desc: null,
      higherLevel: null,
      page: null,
      range: null,
      components: null,
      material: null,
      ritual: null,
      duration: null,
      concentration: null,
      castingTime: null,
      level: null,
      school: null,
      classes: null,
      subclasses: null,
      url: null
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
      let classArr = [];
      this.spell.classes.forEach(function(el) {
        classArr.push(el.name);
      });
      let classes =
        "<p><strong>Classes: </strong>" + classArr.join(", ") + ".</p>";

      return classes;
    },
    formattedDescription: function() {
      let description = (
        "<p><strong>Description: </strong>" +
        this.spell.desc.join("</p></p>") +
        "</p>"
      ).replace("â€™", "'");
      return description;
    },
    formattedDuration: function() {
      return "<strong>D&nbsp;</strong>" + this.spell.duration;
    },
    formattedCastingTime: function() {
      return "<strong>C&nbsp;</strong>" + this.spell.castingTime;
    },
    formattedComponents: function() {
      let array = [];
      let components = this.spell.components;
      for (let i = 0; i < components.length; i++) {
        let componentString;

        switch (components[i]) {
          case "V":
            componentString = "Verbal";
            break;
          case "S":
            componentString = "Somatic";
            break;
          case "M":
            componentString = this.spell.material
              ? this.spell.material.substring(0, this.spell.material.length - 1)
              : ""; //remove trailng fullstop
            break;
          case "F":
            componentString = "Focus";
            break;
          case "DF":
            componentString = "Divine Focus";
            break;
          case "XP":
            componentString = "XP Cost";
            break;
        }

        array.push(componentString);
      }

      let result =
        "<p><strong>Components: </strong>" + array.join(", ") + ".</p>";

      return result;
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
