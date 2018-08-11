
<template>
  <div cols="4">
    <b-card :title="spell.name"
            :sub-title="formattedLevel + ' ' + formattedRange"
            img-top
            tag="article"
            class="mx-auto m-1 spell-card shadow"
            :border-variant="classColor"
            header-bg-variant="primary"
            header-text-variant="white">
      <p class="card-text text-sm " align-h="start">
        <b-button v-b-toggle="'descSpell' + spell.index" size="sm" class="shadow-sm " variant="primary">Details</b-button>
        <b-button v-b-toggle="'componentText' + spell.index" size="sm" variant="secondary">Components</b-button>
        <b-collapse :id="'descSpell'+spell.index" class="details-text">
          <br />
          <strong>Description: </strong>
          {{formattedDescription}}
        </b-collapse>
        <b-collapse :id="'componentText'+spell.index" class="component-text">
          <br />
          <strong>Components: </strong>
          {{formattedComponents}}
        </b-collapse>
      </p>
    </b-card>
  </div>
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
        if (this.spell.classes.indexOf('Wizard') != -1) {
          return 'primary';
        }
        else {
          return 'secondary';
        }
        return this.spell.class;
      }
    }
  }
</script>
<style>
  .details-text {
    font-size: 0.85rem;
  }
  .component-text {
    font-size: 0.85rem;
  }
</style>
