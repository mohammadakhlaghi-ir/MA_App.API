import React, { useEffect, useState } from "react";
import { View, Text, ActivityIndicator } from "react-native";
import api from "./api";
export interface AppInfoDto {
  title: string;
  description: string;
}

export default function Index() {
  const [appInfo, setAppInfo] = useState<AppInfoDto | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    api
      .get<AppInfoDto>("/Home/GetAppInfo")
      .then((response) => {
        setAppInfo(response.data);
      })
      .catch((error) => {
        console.error("Error fetching app info:", error.message);
        console.log(error.config);
        if (error.response) {
          console.log("Response:", error.response.status, error.response.data);
        } else if (error.request) {
          console.log("No response received:", error.request);
        }
      })
      .finally(() => {
        setLoading(false);
      });
  }, []);

  if (loading) return <ActivityIndicator size="large" />;

  return (
    <View
      style={{
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      {appInfo ? (
        <>
          <Text>App Name: {appInfo.title}</Text>
          {appInfo.description && (
            <Text>Description: {appInfo.description}</Text>
          )}
        </>
      ) : (
        <Text>Failed to load app info.</Text>
      )}
    </View>
  );
}
