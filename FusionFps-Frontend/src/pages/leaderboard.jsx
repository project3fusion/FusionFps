import { Fragment } from "react";
import Layout from "components/layout";
import GlobalStyles from "assets/styles/GlobalStyles"

import Header from "sections/Header/v2";
import PageHeader from "sections/LeaderboardPage/PageHeader";
import Leaderboard from "sections/LeaderboardPage";
import Footer from "sections/Footer/v1";

export default function LeaderboardPage() {
  return (
    <Fragment>
      <Layout>
        <GlobalStyles />

        <Header />
        <PageHeader currentPage="ledearboard" pageTitle="ledearboard" />
        <Leaderboard />
        <Footer />
      </Layout>
    </Fragment>
  );
}
