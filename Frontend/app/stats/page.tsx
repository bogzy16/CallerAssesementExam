import CallTable from "@/app/stats/table";
import { DefaultPagination, prefetchPaginatedQuery } from "@/hooks/query";
import { HydrationBoundary, dehydrate } from "@tanstack/react-query";

const StatsPage = async () => {
  const queryClient = await prefetchPaginatedQuery("/User", DefaultPagination);

  return (
    <main>
      <HydrationBoundary state={dehydrate(queryClient)}>
        <CallTable />
      </HydrationBoundary>
    </main>
  );
};

export default StatsPage;
