import { Fragment } from "react";
import Layout from "components/layout";
import GlobalStyles from "assets/styles/GlobalStyles"

import Header from "sections/Header/v2";
import Register from "sections/AuthPages/Register";


export default function RegisterPage() {
  return (
    <Fragment>
      <Layout>
        <GlobalStyles />

        <Header />
        <Register />
      </Layout>
    </Fragment>
  );
}
