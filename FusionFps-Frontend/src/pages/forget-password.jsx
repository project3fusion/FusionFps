import { Fragment } from "react";
import GlobalStyles from "assets/styles/GlobalStyles"
import Layout from "components/layout";

import Header from "sections/Header/v2";
import ForgetPassword from "sections/AuthPages/ForgetPassword";

export default function PasswordReset() {
  return (
    <Fragment>
      <GlobalStyles />
      <Layout>
        <Header />
        <ForgetPassword />
      </Layout>
    </Fragment>
  );
}
