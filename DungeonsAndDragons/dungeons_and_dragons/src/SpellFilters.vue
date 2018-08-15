<template>
    <b-row>
        <b-col sm=12>
            <h3 class="my-2 mt-4">Filters</h3>
        </b-col>
        <b-col sm="12">
            <b-form-group label="<strong>Classes</strong>">
                <b-form-checkbox-group v-model="selectedClassFilters"  :options="getFilterOptions">
                </b-form-checkbox-group>
            </b-form-group>
        </b-col>
    </b-row>
</template>

<script>
export default {
  name: "SpellFilters",
  props: {
    classFilters: Array
  },
  data: function() {
    return {
      localClassFilters: this.classFilters,
      selectedClassFilters: this.classFilters
    };
  },
  computed: {
    getFilterOptions: function() {
      let arr = [];
      for (let i = 0; i < this.localClassFilters.length; i++) {
        let row = {
          text:
            this.localClassFilters[i][0].toUpperCase() +
            this.localClassFilters[i].slice(1),
          value: this.localClassFilters[i]
        };
        arr.push(row);
      }
      return arr;
    }
  },
  watch: {
    selectedClassFilters(val) {
      this.$emit("classFilters", val);
    }
  }
};
</script>
