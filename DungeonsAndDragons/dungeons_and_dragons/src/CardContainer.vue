
<template>
  <el-col :span="24">
    <el-card class="box-card">
      <div slot="header" class="clearfix">
        <span>Card name</span>
      </div>
      <div v-for="o in 4" :key="o" class="text item">
        {{'List item ' + o }}
      </div>
    </el-card>
  </el-col>
</template>

<script>

  export default {
    name: 'CardContainer',
    props: {
      id: '',
      index: '',
      name: '',
      desc: '',
      level: ''
    }
  }
</script>
