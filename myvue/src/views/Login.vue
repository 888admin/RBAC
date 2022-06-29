<template>
  <el-card class="box-card">
    <div slot="header" class="clearfix">
      <span>登录系统</span>
      <el-button style="float: right; padding: 3px 0" @click="reg" type="text">注册</el-button>
    </div>
    <div>
      <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
        <el-form-item label="用户名" prop="UserName">
          <el-input v-model="ruleForm.UserName"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="Password">
          <el-input v-model="ruleForm.Password" show-password></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm('ruleForm')">登录</el-button>
          <el-button @click="resetForm('ruleForm')">重置</el-button>
        </el-form-item>
      </el-form>
    </div>
  </el-card>
</template>

<script>
export default {
  data () {
    return {
      ruleForm: {
        UserName: '',
        Password: '',
      },
      rules: {
        UserName: [
          { required: true, message: '请输入用户名', trigger: 'blur' },
          { min: 2, max: 10, message: '长度在 3 到 5 个字符', trigger: 'blur' }
        ],
        Password: [
          { required: true, message: '请选择密码', trigger: 'change' },
          { min: 2, max: 10, message: '长度在 3 到 5 个字符', trigger: 'blur' }
        ]
      }
    };
  },
  methods: {
    submitForm (formName) {
      debugger
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$http.post('/api/Admin/Login', this.ruleForm).then(res => {
            debugger
            if (res.data.Code > 0) {
              this.$message.error(res.data.Msg)
            }
            else {
              this.$message({
                message: '恭喜你，登录成功',
                type: 'success'
              });
              debugger
              localStorage.setItem("token", res.data.Token)

              this.$router.push('/Menu')
            }
          })
        } else {
          console.log('error submit!!');
          return false;
        }
      });
    },
    resetForm (formName) {
      this.$refs[formName].resetFields();
    },
    reg () {


    }
  }
}
</script>


<style>
.text {
  font-size: 14px;
}

.item {
  margin-bottom: 18px;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}
.clearfix:after {
  clear: both;
}

.box-card {
  width: 480px;
}
</style>