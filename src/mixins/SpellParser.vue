<script>
export default {
  name: "SpellParser",
  created: function() {
    this.greetings();
  },
  methods: {
    greetings: function() {
      console.log("Howdy my good fellow!");
    }
  },
  props: {
    spell: {
      index: Number,
      name: String,
      desc: Array,
      higherLevel: String,
      range: String,
      ritual: Boolean,
      duration: String,
      concentration: Boolean,
      castingTime: String,
      level: String,
      school: String,
      class: Array,
      source: String,
      page: String
    }
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
      return "<strong class='text-danger'>" + this.spell.level + "</strong>";
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
      let description = this.convertJsonArrayToHtml(this.spell.desc);

      if (this.spell.higherLevel) {
        let higherLevel =
          "<strong>At Higher Levels </strong>" +
          this.convertJsonArrayToHtml(this.spell.higherLevel);
        description += higherLevel;
      }
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
        "<strong class='text-success'>Casting&nbsp;</strong>" +
        this.spell.castingTime
      );
    },
    formattedComponents: function() {
      let array = [];
      if (this.spell.components.includes("V")) {
        array.push("Verbal");
      }
      if (this.spell.components.includes("S")) {
        array.push("Somatic");
      }
      if (this.spell.components.includes("M")) {
        array.push(`Material (${this.spell.material})`);
      }
      if (array.length > 0) {
        return (
          "<strong class='text-primary'>Components</strong><p>" +
          array.join(", ") +
          "</p>"
        );
      }
      return "";
    }
  }
};
</script>