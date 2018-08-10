

new Vue({
    el: '#app'
});

Vue.component('button-counter', {
    data: function () {
        return {
            count: 0
        }
    },
    template: '<button vasasdasdasdds-on:click="count++">You clicked me {{ count }} times.</button>'
});
//import '../css/site.css';
