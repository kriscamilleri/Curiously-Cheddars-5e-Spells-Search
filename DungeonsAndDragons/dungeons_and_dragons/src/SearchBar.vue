
<template>

</template>

<script>
  export default {
    name: 'SpellCard',
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
    computed: {
      formattedLevel: function () {
        if (this.spell.level == 0) {
          return 'Cantrip,';
        }

        return 'Level ' + this.spell.level + ',';
      },
      formattedRange: function () {
        return this.spell.range.replace('feet', 'Feet');
      },
      formattedDescription: function () {
        return this.spell.desc.join("\r\n").replace("â€™", "'");
      },
      formattedComponents: function () {
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
              componentString = "Material";
              break;
            case "F":
              componentString = "Focus";
              break;
            case "DF":
              componentString = "Divine Focus";
              break;
            case "XP":
              componentString = "XP Cost"
              break;
          }

          array.push(componentString);
        }

        return array.join(', ') + '.';
      },
      classColor: function () {

        return 'secondary';
      }
    }
  }
  //Stacked progress bar to denote spell class requirement
</script>
<style>
  .details-text {
    font-size: 0.85rem;
  }
  .component-text {
    font-size: 0.85rem;
  }
</style>
