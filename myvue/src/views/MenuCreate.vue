<template>
  <div>
    <el-form ref="form" :model="form" label-width="80px">
      <el-cascader v-model="value" :options="options" :props="{ checkStrictly: true }" clearable></el-cascader>
      <el-form-item label="菜单名称">
        <el-input v-model="form.MenuName"></el-input>
      </el-form-item>
      <el-form-item label="菜单链接">
        <el-input v-model="form.MenuLink"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">立即添加</el-button>
        <el-button>取消</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script>
import { FormItem } from 'element-ui';
export default {
  data () {
    return {
      form: {
        PId: null,
        MenuName: '',
        MenuLink: '',
      },
      value: [],
      options: []
    }
  },
  methods: {
    onSubmit () {
      this.form.PId = this.value.slice(-1)[0];
      console.log(this.form);
      this.$http.post("/api/Menu/AddMenu", this.form).then(res => {
        if (res.data > 0) {
          this.$message.success("添加成功");

          this.$emit("routertable", true);
        }
      })
    },
    Menu () {
      this.$http.get("/api/Menu/QueryCreateMeun").then(res => {
        var reg = new RegExp('\\,"children":\\[]', 'g');
        this.options = JSON.parse(JSON.stringify(res.data).replace(reg, ''));
        console.log(res)
      })
    }
  },
  created () {
    this.Menu();
  },
}
</script>