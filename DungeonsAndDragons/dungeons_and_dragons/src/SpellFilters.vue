<template>
    <b-row>
        <b-col sm=12>
            <h3 class="my-2 mt-4">Filters</h3>
        </b-col>
        <b-col sm="12">
            <b-form-group label="<strong>Classes</strong>">
                <b-form-checkbox-group v-model="classFilters"  :options="classOptions">
                </b-form-checkbox-group>
            </b-form-group>
        </b-col>
        
    </b-row>
</template>

<script>
export default {
  name: "SpellFilters",
  data: function() {
    return {
      classFilters: [
        "bard",
        "cleric",
        "druid",
        "paladin",
        "ranger",
        "sorcerer",
        "warlock",
        "wizard"
      ],
      classOptions: [
        { text: "Bard", value: "bard" },
        { text: "Cleric", value: "cleric" },
        { text: "Druid", value: "druid" },
        { text: "Paladin", value: "paladin" },
        { text: "Ranger", value: "ranger" },
        { text: "Sorcerer", value: "sorcerer" },
        { text: "Warlock", value: "warlock" },
        { text: "Wizard", value: "wizard" }
      ]
    };
  },
  methods: {
    toggleClassFilters: function() {
      this.$emit("classFilters", this.classFilters);
    }
  }
};
</script>
